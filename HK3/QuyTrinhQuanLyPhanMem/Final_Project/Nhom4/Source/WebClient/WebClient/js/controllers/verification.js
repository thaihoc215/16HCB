//chart.js
angular
    .module('app')
    .controller('VerificationCtrl', VerificationCtrl)

VerificationCtrl.$inject = ['$scope', '$state', '$http', 'store', 'httpModule', 'tokenModule'];

function VerificationCtrl($scope, $state, $http, store, httpModule, tokenModule) {

    $scope.isVerify = true;

    $scope.code = {
        value: '',
        status: ''
    };

    var user = store.get('user');


    $scope.Verification = function(code) {

        var req = {
            method: 'GET',
            url: httpModule + '/api/web/CheckSecurityCode/' + user.username + '/' + code.value +'/' + tokenModule,
            headers: {
                'Content-Type': 'application/json'
            }
        }

        $http(req).then(function(res){
            var status = res.status;
            if (status == 200) {
                var data = res.data;
                if (data.check) {
                    // true
                    code.status = '';
                    $scope.isVerify = true;
                    store.set('verification', user);
                    $state.go('app.main');
                } else {
                    code.status = 'has-danger';
                    $scope.isVerify = false;
                }
            } else {
                code.status = 'has-danger';
                $scope.isVerify = false;
            }
        }, function(){
            code.status = 'has-danger';
            $scope.isVerify = false;
        });

    }

}