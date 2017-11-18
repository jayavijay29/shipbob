MyApp.controller('deleteController', function ($scope, $routeParams, $http, $route, $window, $location) {
    $scope.trackingID = $routeParams.trackingID;
    var deleteUser = $window.confirm('Are you absolutely sure you want to delete?');
    if (deleteUser) {
        var order = {
            userID: 1,
            trackingID: $scope.trackingID,
            orderID: 1,
            street: 1,
            state: 1,
            zipCode: 1,
        };
        var post = $http({

            method: "POST",
            url: "/api/AjaxAPI/DeleteOrderMethod",
            dataType: 'json',
            data: order,
            headers: { "Content-Type": "application/json" }
        });
        post.success(function (data, status) {
            $location.path('/');
        });

        post.error(function (data, status) {
            $window.alert(data.Message);
        });
    } else {
        $window.history.back();
    }
});