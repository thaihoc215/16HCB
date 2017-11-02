//chart.js
angular
    .module('app')
    .controller('RegisterCtrl', RegisterCtrl)

RegisterCtrl.$inject = ['$scope', '$state', '$http', 'httpServer'];

function RegisterCtrl($scope, $state, $http, httpServer) {
    $scope.username = {};
    $scope.password = {};
    $scope.repassword = {};
    $scope.fullname = {};
    $scope.phone = {};
    $scope.email = {};
    $scope.level = {};

    $scope.isRegister = true;
    $scope.registerSuccess = false;

    $scope.Register = function() {
        $scope.isRegister = true;
        var user = {
            username: $scope.username.value,
            password: $scope.password.value,
            fullname: $scope.fullname.value,
            phone: $scope.phone.value,
            email: $scope.email.value,
            level: 0
        }
        angular.forEach(user, function(value, key) {
            if (key !== 'level' || key !== 'fullname' || key !== 'phone') {
                $scope[key].status = '';
                if (value === undefined || value === '') {
                    $scope[key].status = 'has-danger';
                    $scope.isRegister = false;
                }
            }
        });

        if ($scope.isRegister === true) {
            if ($scope.password.value !== $scope.repassword.value) {
                $scope.password.status = 'has-danger';
                $scope.isRegister = false;
                return;
            }

            var req = {
                method: 'POST',
                url: httpServer + '/api/user',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: user
            }

            $http(req).then(function() {
                //Success
                $scope.registerSuccess = true;
            }, function() {
                //Error
            });
        }

    };
}