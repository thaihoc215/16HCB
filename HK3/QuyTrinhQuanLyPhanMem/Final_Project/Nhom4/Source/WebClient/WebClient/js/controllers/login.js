//chart.js
angular
    .module('app')
    .controller('LoginCtrl', LoginCtrl)

LoginCtrl.$inject = ['$scope', '$state', '$http', 'httpServer', 'store', 'httpModule', 'tokenModule'];

function LoginCtrl($scope, $state, $http, httpServer, store, httpModule, tokenModule) {
    //If user is login
    if (store.get('user') && store.get('verification')) {
        $state.go('app.main');
    } else {
        $scope.isLogin = true;
        $scope.username = {};
        $scope.password = {};
        //Login function
        $scope.Login = function() {

            var username = $scope.username.value;
            var password = $scope.password.value;
            if (username !== undefined && password !== undefined) {
                var req = {
                    method: 'GET',
                    url: httpServer + '/api/login/' + username + '/' + password,
                    headers: {
                        'Content-Type': 'application/json'
                    }
                };
                $http(req).then(function(response) {
                    var status = response.status;
                    //Success
                    if (status === 200) {
                        var user = response.data;

                        var reqServer = {
                            method: 'GET',
                            url: httpModule + '/api/web/getAuthenStatus/' + username + '/' + tokenModule,
                            headers: {
                                'Content-Type': 'application/json'
                            }
                        }

                        $http(reqServer).then(function(responseServer) {
                            var statusServer = responseServer.status;
                            //Success
                            if (statusServer === 200) {

                                var res = responseServer.data;
                                // Enable true 2 verification
                                if (res.isEnable === true) {
                                    user.icon = 'fa fa-shield';
                                    store.set('user', user);
                                    $state.go('appSimple.verification');
                                } else {
                                    user.icon = 'fa fa-unlock';
                                    store.set('user', user);
                                    store.set('verification', user);
                                    $state.go('app.main');
                                }

                            } else {
                                $scope.isLogin = false;
                                $scope.username.status = 'has-danger';
                                $scope.password.status = 'has-danger';
                            }
                            
                        }, function() {
                            //Error
                            $scope.isLogin = false;
                            $scope.username.status = 'has-danger';
                            $scope.password.status = 'has-danger';
                        });
                        
                        
                    } else {
                        $scope.isLogin = false;
                        $scope.username.status = 'has-danger';
                        $scope.password.status = 'has-danger';
                    }
                }, function() {
                    //Error
                    $scope.isLogin = false;
                    $scope.username.status = 'has-danger';
                    $scope.password.status = 'has-danger';
                });
            } else {
                $scope.isLogin = false;
                if (username === undefined || username === '') {
                    $scope.username.status = 'has-danger';
                }
                if (password === undefined || password === '') {
                    $scope.password.status = 'has-danger';
                }
            }
        }
    }
}