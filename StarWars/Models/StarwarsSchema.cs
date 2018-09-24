using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class StarWarsSchema : Schema
    {
        //public StarWarsSchema(Func<Type, GraphType> resolveType) : base(resolveType)
        //{
        //    Query = (StarWarsQuery)resolveType(typeof(StarWarsQuery));
        //    Mutation = (StarWarsMutation)resolveType(typeof(StarWarsMutation));
        //}

        public StarWarsSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<StarWarsQuery>();
            Mutation = dependencyResolver.Resolve<StarWarsMutation>();
        }
    }
    
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public Newtonsoft.Json.Linq.JObject Variables { get; set; }
    }
}
