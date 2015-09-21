var fm = angular.module("FileManager", []);

fm.controller("FileManagerCtrl", function ($scope, $http, $log) {
    console.log(paramsFromView.baseUrl);
    var RootFilesUrl = paramsFromView.baseUrl + "/api/File/getbasedirectoryfiles",
        PathFilesUrl = paramsFromView.baseUrl + "/api/File/getfiles";

    var provise = $http.get(RootFilesUrl);

    provise.then(fulfilled, rejected);

    function fulfilled(response) {
        $scope.item = response.data;
    };

    function rejected(response) {
        console.log("err" + response);
        $log.error(response.status);
        $log.error(response.Message);
    };

    $scope.GetPathFiles = function (name) {

        if (name.lastIndexOf('.') + 1 > 0) return false;

        provise = $http.get(PathFilesUrl + "?path=" + $scope.item.CurrentPath + "\\" + name);
        provise.then(fulfilled, rejected);
    }

    $scope.UpPath = function () {
        provise = $http.get(PathFilesUrl + "?path=" + $scope.item.UpPath);
        provise.then(fulfilled, rejected);
    };
});