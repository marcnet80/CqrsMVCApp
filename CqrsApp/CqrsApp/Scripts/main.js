function checkboxClick() {
    var elem = document.getElementsByClassName("custom-checkbox");
    var showElem = document.getElementsByClassName("upload-avatar");
    var imgUrlElem = document.getElementById("ImageUrl");
    if (elem && elem[0].checked && showElem) {
        showElem[0].style.display = "block";
        imgUrlElem.readOnly = true;
    } else if (showElem) {
        showElem[0].style.display = "none";
        imgUrlElem.readOnly = false;
    }
};

const defaultSizes = "100px";
var uploadFile = document.getElementById('upload-file');
uploadFile.addEventListener("change", function () {
    if (uploadFile.value) {
        var reader = new FileReader();
        reader.onload = function (e) {
            var elem = document.getElementById("defaul-img");
            elem.src = e.target.result;
            elem.style.width = defaultSizes;
            elem.style.height = defaultSizes;
        };
        reader.readAsDataURL(uploadFile.files[0]);
    }
});