using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Azure.Graphs;
using Microsoft.Azure.Graphs.Elements;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechRecruiting.Models;

namespace TechRecruiting.DataGeneration
{
    public class GraphDataGenerator
    {
        private readonly string _accountKey;
        private readonly string _endpointUrl;
        private readonly string _databaseName;
        private readonly string _graphName;

        public GraphDataGenerator(string accountKey, string endpointUrl, string databaseName, string graphName)
        {
            _accountKey = accountKey;
            _endpointUrl = endpointUrl;
            _databaseName = databaseName;
            _graphName = graphName;
        }

        public async Task GenerateDataAsync(ICollection<Portrait> portraits, ICollection<Candidate> candidates, ICollection<Recruiter> recruiters, ICollection<Acquaintance> acquaintances)
        {
            DocumentClient client = new DocumentClient(new Uri(_endpointUrl), _accountKey);

            Database database = await client.CreateDatabaseIfNotExistsAsync(new Database { Id = _databaseName });
            DocumentCollection collection = await client.CreateDocumentCollectionIfNotExistsAsync(database.SelfLink, new DocumentCollection { Id = _graphName }, new RequestOptions { OfferThroughput = 400 });

            {
                IDocumentQuery<Vertex> query = client.CreateGremlinQuery<Vertex>(
                    collection,
                    $"g.V().drop()"
                );

                while (query.HasMoreResults)
                {
                    await query.ExecuteNextAsync<Vertex>();
                }
            }

            foreach (Portrait portrait in portraits)
            {
                IDocumentQuery<Vertex> query = client.CreateGremlinQuery<Vertex>(
                    collection,
                    $"g.addV('portrait').property('id', '{portrait.Id}').property('imageUrl', '{portrait.ImageUrl}').property('imageAuthorName', '{portrait.ImageAuthorName}').property('imageAuthorId', '{portrait.ImageAuthorId}').property('imageSourceId', '{portrait.ImageSourceId}')"
                );

                while (query.HasMoreResults)
                {
                    await query.ExecuteNextAsync<Vertex>();
                }
            }

            foreach (Candidate candidate in candidates)
            {
                IDocumentQuery<Vertex> query = client.CreateGremlinQuery<Vertex>(
                    collection,
                    $"g.addV('candidate').property('id', '{candidate.Id}').property('firstName', '{candidate.FirstName}').property('lastName', '{candidate.LastName}').property('skillDescription', '{candidate.SkillDescription}')"
                );

                while (query.HasMoreResults)
                {
                    await query.ExecuteNextAsync<Vertex>();
                }
            }

            foreach (Recruiter recruiter in recruiters)
            {
                IDocumentQuery<Vertex> query = client.CreateGremlinQuery<Vertex>(
                    collection,
                    $"g.addV('candidate').property('id', '{recruiter.Id}').property('firstName', '{recruiter.FirstName}').property('lastName', '{recruiter.LastName}')"
                );

                while (query.HasMoreResults)
                {
                    await query.ExecuteNextAsync<Vertex>();
                }
            }

            foreach (Acquaintance acquaintance in acquaintances)
            {
                IDocumentQuery<Vertex> query = client.CreateGremlinQuery<Vertex>(
                    collection,
                    $"g.V('{acquaintance.SourcePersonId}').addE('acquaintance').to(g.V('{acquaintance.DestinationPersonId}'))"
                );

                while (query.HasMoreResults)
                {
                    await query.ExecuteNextAsync<Vertex>();
                }
            }
        }
    }
}