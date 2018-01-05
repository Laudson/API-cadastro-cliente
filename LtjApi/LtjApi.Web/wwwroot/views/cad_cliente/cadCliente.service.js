(function(){
    angular.module('LtjApi')
    .factory('cadClienteService', ['$resource', function($resource) 
    {
        var resource = $resource('/api/admin/cliente/:codigo', { codigo: "@codigo" },
            {
                query: { isArray: true }
            }
        );
        return resource;
    }]);
})();