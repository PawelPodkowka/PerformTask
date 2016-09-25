app.service('GraphService', function($http, ApiConfig) {

    var apiAddress = "http://localhost:54718";

     //ApiConfig().success(function (result) {
     //               apiAddress = result;
     //           })
     //           .error(function (reason) {
     //               apiAddress = "http://localhost:54718";
     //               console.error('Uuups :( I can not find best path ' + reason);
     //           });

    this.getNodes = function() {
        return $http.get("http://localhost:54718/api/nodes");
    };

    this.getShortestPath = function(start, end) {
        var config = {
            params: {
                start: start,
                end: end
            }
        }

        return $http.get("http://localhost:54718/api/graphpath", config);
    };
});