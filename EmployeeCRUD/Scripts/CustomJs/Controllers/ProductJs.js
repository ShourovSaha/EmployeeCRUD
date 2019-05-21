/// <reference path="../../angular.js" />




angular.module("ProductModule", [])
    .controller("ProductContoller", function ($scope, $http) {
        $scope.errorMsg = '';
        $scope.successMsg = '';
        $scope.product = {};
        GetAllProduct();

        //========GetAllProduct========
        function GetAllProduct() {
            $http.get('/Product/GetAllPrroduct')
                .then(function (response) {
                    $scope.productList = response.data;
                },
                    function (error) {
                        $scope.errorMsg = error;
                });
            
        };
        

        //========GetProductDetails========
        $scope.GetProductDetails = function (id) {
            debugger
            $http.get('/Product/GetPrroductbyId/' + id)
                .then(function (response) {
                    $scope.product = response.data;
                },
                    function (error) {
                        $scope.errorMsg = error;
                });          
        };

        //========AddProduct========
        function AddProduct(product) {
            debugger
            
        };


        $scope.UpdateProduct = function () {
            debugger
            $http({
                method: 'post',
                url: '/Product/UpdateProduct',
                data: $scope.product
            }).then(function (response) {
                $scope.product = response.data;
                if (response != null && response != 'undifined') {
                    $scope.successMsg = response.data;
                    GetAllProduct();
                }
            },
                function (error) {
                    $scope.errorMsg = error;
                }
            );
            $scope.Product = {};
        };

        function DeleteProduct(product) {
            debugger

        };
    });
