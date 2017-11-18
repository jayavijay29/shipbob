MyApp.controller('editController', function ($scope, $routeParams, $http, $window, $location) {
    $scope.trackingID = $routeParams.trackingID;
   
    var order = {
        userID: 1,
        trackingID: $scope.trackingID,
        orderID: $scope.Prefix22,
        street: $scope.Prefix33,
        state: $scope.Prefix44,
        zipCode: $scope.Prefix55,
    };

    var post = $http({

        method: "POST",
        url: "/api/AjaxAPI/EditOrderMethod",
        dataType: 'json',
        data: order,
        headers: { "Content-Type": "application/json" }
    });
    post.success(function (data, status) {
        $scope.order = data[0];
    });

    post.error(function (data, status) {
        $window.alert(data.Message);
    });

    $scope.UpdateOrder = function (order) {

        var post = $http({
            method: "POST",
            url: "/api/AjaxAPI/UpdateOrderMethod",
            dataType: 'json',
            data: order,
            headers: { "Content-Type": "application/json" }
        });
        post.success(function (data, status) {
            $location.path('/viewOrderUser/' + order.userID);
        });

        post.error(function (data, status) {
            $window.alert(data.Message);
        });
    }
});