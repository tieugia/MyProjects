var video = document.getElementById('video');
var canvas = document.getElementById('canvas');
var photo = document.getElementById('photo');
var btn = document.getElementById('btn');

// Kết nối với webcam laptop
navigator.mediaDevices.getUserMedia({
  video: true,
  audio: false
})
// Show webcam lên màn hình
  .then(function (stream) {
    video.srcObject = stream;
    video.play();
  })
  .catch(function (err) {
    console.log("An error occurred: " + err);
  });

var width = 500;
var height = 350;

video.addEventListener('canplay', function (ev) {
  if (!streaming) {
    height = video.videoHeight / (video.videoWidth / width);
    if (isNaN(height)) {
      height = width / (4 / 3);
    }
    video.setAttribute('width', width);
    video.setAttribute('height', height);
    canvas.setAttribute('width', width);
    canvas.setAttribute('height', height);
    streaming = true;
  }
}, false);

btn.addEventListener('click', function (ev) { // Khi nhấn nút chụp hình
  takephoto();
  ev.preventDefault();
}, false);
clearphoto();

function clearphoto() {
  var context = canvas.getContext('2d');
  context.fillStyle = "#AAA";
  context.fillRect(0, 0, canvas.width, canvas.height);
  var data = canvas.toDataURL('image/png');
  photo.setAttribute('src', data);
}

function takephoto() {
  var context = canvas.getContext('2d');
  if (width && height) {
    canvas.width = width;
    canvas.height = height;
    context.drawImage(video, 0, 0, width, height);
    var data = canvas.toDataURL('image/png');
    photo.setAttribute('src', data);
  } else {
    clearphoto();
  }
}