var module = angular.module('CheckoutKataApp', [])


// Service Factories

module.factory("offersService", function ($http, $q) {
    var _offers = [];
    var _isInit = false;
    var _isReady = function () { return _isInit; };

    var _getOffers = function () {
        var deferred = $q.defer();
        $http.get("/api/offers")
            .then(
                function (result) {
                    // success
                    angular.copy(result.data, _offers);
                    _isInit = true;
                    deferred.resolve();
                },
                function () {
                    // error
                    deferred.reject();
                });
        return deferred.promise;
    };

    return {
        offers: _offers,
        getOffers: _getOffers,
        isReady: _isReady
    };
});

module.factory("inventoryService", function ($http, $q) {
    var _inventory = [];
    var _isInit = false;
    var _isReady = function () { return _isInit; };

    var _getInventory = function () {
        var deferred = $q.defer();
        $http.get("/api/inventory")
            .then(
                function (result) {
                    // success
                    angular.copy(result.data, _inventory);
                    _isInit = true;
                    deferred.resolve();
                },
                function () {
                    // error
                    deferred.reject();
                });
        return deferred.promise;
    };

    return {
        inventory: _inventory,
        getInventory: _getInventory,
        isReady: _isReady
    };
});

module.factory("cartService", function ($http, $q) {
    var _cart = [];
    var _id = null;
    var _isInit = false;
    var _isReady = function () { return _isInit; };

    var _getNewCartId = function () {
        var deferred = $q.defer();
        $http.get("/api/cart/new")
            .then(
                function (result) {
                    // success
                    _id = result.data;
                    _isInit = true;
                    deferred.resolve();
                },
                function () {
                    // error
                    deferred.reject();
                });
        return deferred.promise;
    };

    var _getCart = function (id) {
        var deferred = $q.defer();
        $http.get("/api/cart/" + id)
            .then(
                function (result) {
                    // success
                    angular.copy(result.data, _cart);
                    deferred.resolve();
                },
                function () {
                    // error
                    deferred.reject();
                });
        return deferred.promise;
    };

    return {
        cart: _cart,
        getCart: _getCart,
        getNewCartId: _getNewCartId,
        isReady: _isReady,
        id: _id
    };
});

// Controllers

module.controller('inventoryController', ['$scope', '$http', 'inventoryService', function ($scope, $http, inventoryService) {
    $scope.inventoryContents = [];

    if (!inventoryService.isReady()) {
        inventoryService.getInventory()
        .then(function () {
            // success
            $scope.inventoryContents = inventoryService.inventory;
        },
        function () {
            // error
            alert("could not load inventory");
        });
    }

    $scope.addToCart = function (index) {
        var item = $scope.inventoryContents[index];
        $scope.$emit('addItem', [item.id, item.sku]);
    }
}]);

module.controller('offerController', ['$scope', '$http', 'offersService', function ($scope, $http, offersService) {
    $scope.offers = [];
    
    if (!offersService.isReady()) {
        offersService.getOffers()
        .then(function () {
            // success
            $scope.offers = offersService.offers;
        },
        function () {
            // error
            alert("could not load offers");
        });
    }

    $scope.getOfferText = function($index) {
        var item = $scope.offers[$index];
        return "For item " + item.SKU + ", Get " + item.OfferQuantity + " for " + item.OfferPrice + ".";
    } 
}]);

module.controller('cartController', ['$scope', '$http', 'cartService', function ($scope, $http, cartService) {
    $scope.cartContents = [];
    $scope.cartId = "";

    if (!cartService.isReady()) {
        cartService.getNewCartId()
        .then(function () {
            // success
            $scope.cartId = cartService.id;
        },
        function () {
            // error
            alert("could not fetch a cart id.");
        })
    }

    $scope.fetchCart = function () {
        cartService.getCart($scope.cartId)
        .then(function () {
            // success
            $scope.cartContents = dataService.cart;
        },
        function () {
            // error
            alert("could not load cart");
        });
    }

    $scope.$on('addItem', function (event, sku) {

    });

    $scope.addCartItem = function () {
       // 
    }

    $scope.removeCartItem = function (index) {
      //  $scope.items.splice(index, 1);
    }

}]);
