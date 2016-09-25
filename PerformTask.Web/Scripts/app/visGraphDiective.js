angular.module('ang.mod.visgraph', [])
       .directive('visGraph', [function () {
           return {
               restrict: 'AE',
               scope: {
                   data: '=data',
                   path: '=path',
                   options: '=options',
                   event: '@event',
                   callback: '&'
               },   
               link: function (scope, element, attributes) {
                   var mygraph = null;
                   var container = element[0],
                       buildGraph = function (scope) {
                       var graph = null;
                       graph = new vis.Network(container, scope.data, scope.options);
                       return graph.on(scope.event, function (properties) {
                           if (properties.nodes.length !== 0) {
                               scope.callback({ params: properties });
                           }
                       });
                   };
                   scope.$watch('data', function (newval, oldval) {
                      mygraph = buildGraph(scope);
                   }, true);

                   scope.$watch('path', function (newval, oldval) {
                       if (newval) {
                           mygraph.body.data.edges.get().forEach(
                               function (item, index) {
                                   mygraph.body.data.edges.update([{ id: item.id, color: '#2B7CE9', value: 1 }]);
                                   newval.some(function (connection) {
                                       if ((connection.from == item.from && connection.to == item.to)
                                           || (connection.to == item.from && connection.from == item.to)) {
                                           mygraph.body.data.edges.update([{ id: item.id, color: '#73F700', value: 3 }]);
                                       }
                                   });
                               }
                           );
                       }
                   }, true);
               }
           };
       }]);