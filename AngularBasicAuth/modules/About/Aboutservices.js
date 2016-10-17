'use strict';

var myApp = angular.module('About');

myApp.factory('UploadService', ['Base64', '$http', '$cookieStore', '$rootScope', '$timeout',
        function (Base64, $http, $cookieStore, $rootScope, $timeout) {
            var service = {};

            service.uploadFile = function () {

                alert('Uploading please wait');

            };


            return service;

        }]);

myApp.service('fileUpload', ['$http', function ($http) {

    this.uploadFileToUrl = function (file, uploadUrl) {
        var fd = new FormData();
        fd.append('file', file);

        alert(uploadUrl);
        $http.post(uploadUrl, fd, {dataType:'jsonp', transformRequest: angular.identity,headers: {'Content-Type': undefined }} )
        .success(function (response) {

            alert("Upload Success");

        })

        .error(function (response) {


            alert(response);

        });
}
}]);

