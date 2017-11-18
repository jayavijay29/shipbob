MyApp.controller('MyController', function ($scope, $location, $anchorScroll, $http, $window, $route) {
    $scope.IsVisible = false;
   
    var user;
    
    var post = $http({
        method: "POST",
        url: "/api/AjaxAPI/SelectMethod",
        dataType: 'json',
        headers: { "Content-Type": "application/json" }
        
    });
    
    post.success(function (data, status) {
        $scope.user = data;
        $scope.IsVisible = true;
    });

    post.error(function (data, status) {
        $window.alert(data.Message);
    });

    //Adding Users
    $scope.Create = function () {

        var user = {
            firstName: $scope.Prefix1,
            lastName: $scope.Prefix2
        };
        var post = $http({
            method: "POST",
            url: "/api/AjaxAPI/AddMethod",
            dataType: 'json',
            data: user,
            headers: { "Content-Type": "application/json" }
        });
        
        post.success(function (data, status) {
            $scope.user = data;
            $scope.IsVisible = true;
            $route.reload();
            //$location.path('/');
        });

        post.error(function (data, status) {
            $window.alert(data.Message);
        });
    }
});