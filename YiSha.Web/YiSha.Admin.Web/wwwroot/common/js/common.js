//获取地址栏参数
function getQueryString(name) {
    var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i');
    var r = window.location.search.substr(1).match(reg);
    if (r != null) {
        return unescape(r[2]);
    }
    return null;
}

//格式化日期
Date.prototype.format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        }
    }
    return fmt;
}
//初始化文本编辑器
function initSummernote(element, fileModule, height) {
    if (!height) {
        height = "220px";
    }
    $('#' + element).summernote({
        height: height,
        fontNames: ['宋体', '楷体', '黑体'],
        lang: 'zh-CN',
        dialogsInBody: true,
        callbacks: {
            onImageUpload: function (files, editor, welEditable) {
                uploadSummerNoteImage(files[0], editor, welEditable, fileModule, element);
            }
        }
    });
}
function uploadSummerNoteImage(file, editor, welEditable, fileModule, element) {
    var formdata = new FormData();
    formdata.append("fileList", file);
    ys.ajaxUploadFile({
        url: '/File/UploadFile?fileModule=' + fileModule,
        data: formdata,
        success: (obj) => {
            if (obj.Tag == 1) {
                $("#" + element).summernote('insertImage', obj.Data, '/');
            }
            else {
                ys.msgError(obj.Message);
            }
        }
    })
}