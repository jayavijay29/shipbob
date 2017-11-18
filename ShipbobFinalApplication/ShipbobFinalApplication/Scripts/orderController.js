MyApp.controller('orderController', function ($scope, $routeParams, $http, $window, $location) {
    
    var eorder;
    $scope.IsVisible = false;
    var order;
    var orderTemp;
    var post = $http({
        method: "POST",
        url: "/api/AjaxAPI/SelectOrderMethod",
        dataType: 'json',
        headers: { "Content-Type": "application/json" }

    });

    post.success(function (data, status) {
        $scope.order = data;
        $scope.IsVisible = true;
        
    });

    post.error(function (data, status) {
        $window.alert(data.Message);
    });



    $scope.CreateOrder = function () {
        var order = {
            userID: $routeParams.userID,
            trackingID: $scope.Prefix11,
            orderID: $scope.Prefix22,
            street: $scope.Prefix33,
            state: $scope.Prefix44,
            zipCode: $scope.Prefix55,
        };

        var post = $http({

            method: "POST",
            url: "/api/AjaxAPI/CreateOrderMethod",
            dataType: 'json',
            data: order,
            headers: { "Content-Type": "application/json" }
        });
        post.success(function (data, status) {
            $scope.order = data;
            $scope.IsVisible = true;
            $location.path('/viewOrderUser/' + order.userID);
        });

        post.error(function (data, status) {
            $window.alert(data.Message);
        });
    }
    $scope.eorder;

    $scope.editOrder = function (index) {
        eorder = $scope.order[index];
        var trackID = eorder.trackingID;
        var order = {
            userID: 1,
            trackingID: eorder.trackingID,
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
            $scope.eorder = data.data;
            $scope.IsVisible = false;
            $location.path('/viewOrderUser');
        });

        post.error(function (data, status) {
            $window.alert(data.Message);
        });
    }

});