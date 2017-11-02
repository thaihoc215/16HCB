//chart.js
angular
    .module('app')
    .controller('UpdateCtrl', UpdateCtrl)

UpdateCtrl.$inject = ['$scope', 'httpServer', 'store', '$http'];

function UpdateCtrl($scope, httpServer, store, $http) {

    $scope.isTrue = true;
    $scope.isUpdate = false;

    var user = store.get('user');

    $scope.user = {
        username: {
            value: user.username,
            status: ''
        },
        email: {
            value: user.email,
            status: ''
        },
        fullname: {
            value: user.fullname,
            status: ''
        },
        phone: {
            value: user.phone,
            status: ''
        },
        password: {
            value: '',
            status: ''
        },
        repassword: {
            value: '',
            status: ''
        }
    };

    $scope.updateUser = function() {

        if ($scope.user.password.value !== $scope.user.repassword.value) {
            $scope.user.password.status = 'has-danger';
            $scope.user.repassword.status = 'has-danger';
            $scope.isTrue = false;
            $scope.status = 'Sorry, The password is not match.';
            return;
        }

        $scope.isTrue = true;

        var userUpdate = {
            id: user.id,
            username: $scope.user.username.value,
            fullname: $scope.user.fullname.value,
            phone: $scope.user.phone.value,
            email: $scope.user.email.value,
            level: user.level
        };

        if ($scope.user.password.value !== '') {
            userUpdate.password = $scope.user.password.value;
        } else {
            userUpdate.password = user.password;
        }

        var req = {
            method: 'PUT',
            url: httpServer + '/api/user/',
            data: userUpdate,
            headers: {
                'Content-Type': 'application/json'
            }
        }

        $http(req).then(function(response) {
            //Success
            $scope.isUpdate = true;
            var req_user = {
                method: 'GET',
                url: httpServer + '/api/user/5',
                headers: {
                    'Content-Type': 'application/json'
                }
            };

            $http(req).then(function(response) {
                //Success
                store.set('user', response.data);
                user = store.get('user');
            }, function() {
                //Error
                $scope.status = 'Update user fail.';
            });


        }, function() {
            //Error
            $scope.status = 'Update user fail.';
        });
    };
}