'use strict';

var myapp = angular.module('About');

myApp.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);


myApp.controller('AboutController', ['$scope', '$rootScope', '$location', 'UploadService', 'fileUpload',
    function ($scope, $rootScope, $location, UploadService, fileUpload) {

        //TODO Code here

        $scope.SelectedFiles = [];
        var files = {};

        $scope.UploadFile = function () {

            var file = $scope.SelectedFiles;

            console.log('file is ');
            console.dir(file);

            var uploadUrl = "http://localhost:58397/api/UploadFile/Upload";
            fileUpload.uploadFileToUrl(file, uploadUrl);


            // UploadService.uploadFile();
        };

        $scope.file_changed = function (ele) {

            var files = ele.files;
            var l = files.length;

            for (var i = 0; i < l; i++) {
                $scope.SelectedFiles.push(files[i]);
                $scope.$apply();
            }
        };

    }]);