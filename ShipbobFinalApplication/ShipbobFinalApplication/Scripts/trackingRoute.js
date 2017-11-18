MyApp.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "/Pages/userView.html",
            controller: "MyController"
        })

        .when("/red/:userID", {
            templateUrl: "/Pages/red.html",
            controller: "orderController",
        })

        .when("/viewOrderUser/:userID", {
            templateUrl: "/Pages/viewOrderUser.html",
            controller: "viewOrderUserController",
        })
        .when("/viewOrderUser", {
            templateUrl: "/Pages/viewOrderUser.html",
           
        })

        .when("/trackingHistory", {
            templateUrl: "/Pages/trackingHistory.html",
            controller: "orderController",
        })

        .when("/editOrder/:trackingID", {
            templateUrl: "/Pages/editOrder.html",
            controller: "editController",
        })

        .when("/deleteOrder/:trackingID", {
            templateUrl: "/Pages/viewOrderUser.html",
            controller: "deleteController"
        });
});