from airflow import DAG
from airflow.operators.http_operator import SimpleHttpOperator
from airflow.operators.python_operator import PythonOperator
from airflow.contrib.hooks.redis_hook import RedisHook
from airflow.sensors.base_sensor_operator import BaseSensorOperator
from airflow.utils.decorators import apply_defaults
from airflow.utils.dates import days_ago
from airflow.models import Variable
from airflow.hooks.http_hook import HttpHook
from datetime import timedelta, datetime
import json
# from base64 import b64encode
import base64
from operators.task_track_operator import TaskTrackOperator

default_args = {
    'owner': 'airflow',
    'retried': 1,
    'retry_delay': timedelta(minutes=1),
    'start_date': datetime(2021, 6, 11),
}

export_send_attachment_config = Variable.get(
    'export_send_attachment_config',  deserialize_json=True, default_var=None)

with DAG(
    'export_send_attachment',
    default_args=default_args,
    schedule_interval=timedelta(seconds=3),
    # schedule_interval=export_send_attachment_config["interval"],
    user_defined_filters={
        'fromjson': lambda s: json.loads(s),  # load json to python dict
        'tojson': lambda s: json.dumps(s),  # python dict to json string
        'base64': lambda s: base64.b64encode(s.encode("ascii")).decode("ascii"),
    },
    catchup=False
) as dag:

    requestData = export_send_attachment_config['api']['export']['RequestData']
    result = json.dumps(requestData)
    result = base64.b64encode(result.encode("ascii")).decode("ascii")
    # api_endpoint = export_send_attachment_config['api']['endpoint']
    header = export_send_attachment_config['header']
    OperationName = export_send_attachment_config['api']['export']['OperationName']

    export = SimpleHttpOperator(
        task_id="export",
        http_conn_id=export_send_attachment_config['api']['conn_id'],
        endpoint='',
        data=json.dumps({"RequestData": result,
                         "OperationName": OperationName}),
        headers=header,
        xcom_push=True,
    )

    request = export_send_attachment_config['api']['send']['RequestData']
    resultt = json.dumps(request)
    resultt = base64.b64encode(resultt.encode("ascii")).decode("ascii")
    OperationNamee = export_send_attachment_config['api']['send']['OperationName']

    Send = SimpleHttpOperator(
        task_id='Send',
        http_conn_id = export_send_attachment_config['api']['conn_id'],
        endpoint='',
        data = json.dumps({"RequestData": resultt,
                         "OperationName": OperationNamee}),
        # headers={"Content-Type": "application/json"},
        headers=header,
        xcom_push=True        
    )

    export >> Send