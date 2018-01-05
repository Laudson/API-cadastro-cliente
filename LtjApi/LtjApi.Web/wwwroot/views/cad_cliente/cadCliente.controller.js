'use strict';

angular.module('LtjApi')
    .controller('cadClienteController', ['$scope', '$state', 'cadClienteService', function ($scope, $state, cadClienteService) {
        var vm = this;
        vm.scope = $scope;
        vm.dadosCarregados = false;
        vm.lista = [];
        vm.filtro = {};
        vm.titulo = "Lista de clientes";

        //Pesquisar
        vm.pesquisar = function () {
            cadClienteService.query({ Titulo: vm.filtro.titulo }, function (data) {
                vm.dadosCarregados = true;
                vm.lista = data;
            });
        };

        //Incluir
        vm.incluir = function () {
            $state.go('LtjApi.cadcliente', { codigo: 0 });
            //console.log('Agora deu certo');
        };

        //Editar
        vm.editar = function (item) {
            $state.go('LtjApi.cadcliente', { codigo: item.codigo });
        };

        //Excluir
        vm.excluir = function (item) {
            swal({
                title: "Deseja realmente excluir este cliente?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Sim, continuar",
                cancelButtonText: "Cancelar",
                closeOnConfirm: false,
                closeOnCancel: true,
                showLoaderOnConfirm: true
            },
                function () {
                    item.$delete(function (data) {
                        if (data.erro)
                            return swal({ title: data.mensagemErro, type: "error" });

                        vm.lista = _(vm.lista).filter(function (i) { return i.codigo != item.codigo });

                        swal.close();
                    });
                });
        };

        //Obter dados
        vm.obter = function (codigo) {
            if (codigo > 0) {
                cadClienteService.get({ codigo: codigo }, function (data) {
                    vm.entidade = data;
                    vm.dadosCarregados = true;
                });
            }
            else {
                vm.entidade = {
                    nome: '',                   
                    codigo: null,
                };
                vm.dadosCarregados = true;
            }
        };

        //Carregar
        vm.carregar = function () {
            if ($state.params.codigo)
                vm.obter($state.params.codigo);
            else
                vm.pesquisar();
        };

        //Salvar
        vm.salvar = function () {
            var dados = {};
            if (vm.entidade.codigo == null) {
                vm.entidade.codigo = 0;
            }
            dados.codigo = vm.entidade.codigo;
            dados.nome = vm.entidade.nome;

            cadClienteService.save(dados, function (data) {
                if (data.erro)
                    return swal({ title: data.mensagemErro, type: "error" });

                swal({ title: 'Cliente salvo com sucesso!', type: "success" }, function () {
                    $state.go('LtjApi.listacliente');
                });

            });
        };

        //Cancelar
        vm.cancelar = function () {
            $state.go('LtjApi.listacliente');
        };           

        vm.carregar();
    }]);