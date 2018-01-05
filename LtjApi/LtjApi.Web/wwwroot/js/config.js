/**
 * LtjApi - Responsive Admin Theme
 *
 * LtjApi theme use AngularUI Router to manage routing and views
 * Each view are defined as state.
 * Initial there are written state for all view in theme.
 *
 */
function config($stateProvider, $urlRouterProvider, $ocLazyLoadProvider, IdleProvider, KeepaliveProvider) {

    // Configure Idle settings
    IdleProvider.idle(5); // in seconds
    IdleProvider.timeout(120); // in seconds

    $urlRouterProvider.otherwise("/LtjApi/listacliente");

    $ocLazyLoadProvider.config({
        // Set to true if you want to see what and when is dynamically loaded
        debug: false
    });

    $stateProvider

        .state('LtjApi', {
            abstract: true,
            url: "/LtjApi",
            templateUrl: "views/common/content.html",
        })
        .state('LtjApi.cadcliente', {
            url: "/cad_cliente/:codigo",
            templateUrl: "views/cad_cliente/cadCliente.html",
            data: { pageTitle: 'Cadastro cliente' }
        })
        .state('LtjApi.listacliente', {
            url: "/listacliente",
            templateUrl: "views/cad_cliente/listaCliente.html",
            data: { pageTitle: 'Lista cliente' }
        });
}

angular
    .module('LtjApi')
    .config(config)
    .run(function($rootScope, $state) {
        $rootScope.$state = $state;
    });
