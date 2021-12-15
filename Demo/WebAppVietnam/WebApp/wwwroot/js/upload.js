const upload = (uri, fd, func) => {
    $.ajax({
        url: uri,
        method: 'post',
        data: fd,
        contentType: false,
        processData: false,
        success: func
    })
}