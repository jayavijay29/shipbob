MyApp.controller('viewOrderUserController', function ($scope, $routeParams, $http, $window, $location) {

    $scope.userID = $routeParams.userID;
    var orderTemp = {
        userID: $scope.userID,
        trackingID: 1,
        orderID: 1,
        street: 1,
        state: 1,
        zipCode: 1,
    };
    
    var post = $http({

        method: "POST",
        url: "/api/AjaxAPI/ViewOrderUserMethod",
        dataType: 'json',
        data: orderTemp,
        headers: { "Content-Type": "application/json" }
    });
    post.success(function (data, status) {
        $scope.order = data;
    });

    post.error(function (data, status) {
        $window.alert(data.Message);
    });
});