using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndDragons5thEditionServices
{
    public class MongoDbService
    {
        private readonly IMongoDatabase mongoDatabase;

        #region Contructors
        public MongoDbService(string userName = "DungeonsAndDragonsApp", string password = "spRFiP7a2Qp49Cp", string dbName = "DungeonsAndDragons")
        {
            string connectionString = String.Format("mongodb + srv://{0}:{1}@danscluster-vfjfz.gcp.mongodb.net/{2}?retryWrites=true", userName, password, dbName);

            IMongoClient mongoClient = new MongoClient(connectionString);
            mongoDatabase = mongoClient.GetDatabase(dbName);
        }
        #endregion

        #region Private Functions
        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            IMongoCollection<T> collection = mongoDatabase.GetCollection<T>(collectionName);
            return collection;
        }

        private List<T> GetAllDocuments<T>(string collectionName)
        {
            IMongoCollection<T> collection = GetCollection<T>(collectionName);

            FilterDefinition<T> filter = Builders<T>.Filter.Empty;

            IFindFluent<T, T> result =
                collection
                .Find<T>(filter);
            
            return result.ToList<T>();
        }

        private T GetDocumentById<T>(string id, string collectionName)
        {
            ObjectId _id = new ObjectId(id);
            return GetDocumentById<T>(_id, collectionName);
        }

        private T GetDocumentById<T>(ObjectId id, string collectionName)
        {
            IMongoCollection<T> collection = GetCollection<T>(collectionName);

            FilterDefinition<T> filter = Builders<T>.Filter.Eq<ObjectId>("_id", id);

            IFindFluent<T, T> result =
                collection
                .Find<T>(filter);
            
            return result.FirstOrDefault<T>();
        }

        private void InsertDocument<T>(T newDocument, string collectionName)
        {
            IMongoCollection<T> collection = mongoDatabase.GetCollection<T>(collectionName);

            collection.InsertOne(newDocument);
        }

        private void InsertDocuments<T>(List<T> newDocuments, string collectionName)
        {
            IMongoCollection<T> collection = mongoDatabase.GetCollection<T>(collectionName);

            collection.InsertMany(newDocuments);
        }

        private long UpdateDocumentById<T>(string id, UpdateDefinition<T> documentChanges, string collectionName)
        {
            ObjectId _id = new ObjectId(id);
            return UpdateDocumentById<T>(_id, documentChanges, collectionName);
        }

        private long UpdateDocumentById<T>(ObjectId id, UpdateDefinition<T> documentChanges, string collectionName)
        {
            IMongoCollection<T> collection = mongoDatabase.GetCollection<T>(collectionName);

            FilterDefinition<T> filter = Builders<T>.Filter.Eq<ObjectId>("_ID", id);

            UpdateResult updateResult = collection.UpdateOne(filter, documentChanges);
            long updateCount = updateResult.IsAcknowledged ? updateResult.ModifiedCount : 0;
            return updateCount;
        }

        private long DeleteDocumentById<T>(string id, string collectionName)
        {
            ObjectId _id = new ObjectId(id);
            return DeleteDocumentById<T>(_id, collectionName);
        }

        private long DeleteDocumentById<T>(ObjectId id, string collectionName)
        {
            IMongoCollection<T> collection = mongoDatabase.GetCollection<T>(collectionName);

            FilterDefinition<T> filter = Builders<T>.Filter.Eq<ObjectId>("_ID", id);

            DeleteResult deleteResult = collection.DeleteOne(filter);
            return deleteResult.DeletedCount;
        }

        private long ClearCollection<T>(string collectionName)
        {
            IMongoCollection<T> collection = mongoDatabase.GetCollection<T>(collectionName);

            FilterDefinition<T> filter =
                Builders<T>.Filter.Empty;

            DeleteResult deleteResult = collection.DeleteMany(filter);
            return deleteResult.DeletedCount;
        }
        #endregion

        #region Public Functions
        public List<BsonDocument> GetAllDocumentsByCollection(string collectionName)
        {
            return GetAllDocuments<BsonDocument>(collectionName);
        }

        public void InsertOrUpdateFeat (Feat newFeat, string collectionName)
        {

            InsertDocument<Feat>(newFeat, collectionName);
        }

        //public GlobalVehicle GetGlobalVehicle(string country, string vehicleId)
        //{
        //    IMongoCollection<GlobalVehicle> collection = GetModelsCollection<GlobalVehicle>();

        //    FilterDefinition<GlobalVehicle> filter =
        //        Builders<GlobalVehicle>.Filter.And(
        //             Builders<GlobalVehicle>.Filter.In<string>("COUNTRY_ID", GetCountryCodes(country)),
        //             Builders<GlobalVehicle>.Filter.Eq<string>("VEHICLE_ID", vehicleId));

        //    ProjectionDefinition<GlobalVehicle> projection =
        //        Builders<GlobalVehicle>.Projection
        //        .Include("HS")
        //        .Include("HT")
        //        .Include("UT")
        //        .Include("AV")
        //        .Exclude("_id");

        //    IFindFluent<GlobalVehicle, GlobalVehicle> result =
        //        collection
        //        .Find<GlobalVehicle>(filter)
        //        .Project<GlobalVehicle>(projection);

        //    IList<GlobalVehicle> list = result.ToList<GlobalVehicle>();
        //    GlobalVehicle vehicle = (result.Count() > 0) ? list[0] : null;
        //    return vehicle;
        //}

        //public List<OptionMapping> GetGlobalOptions()
        //{
        //    IMongoCollection<OptionMapping> collection = GetOptionsCollection<OptionMapping>();

        //    FilterDefinition<OptionMapping> filter =
        //            Builders<OptionMapping>.Filter.Empty;

        //    ProjectionDefinition<OptionMapping> projection =
        //        Builders<OptionMapping>.Projection
        //        .Exclude("_id");

        //    IFindFluent<OptionMapping, OptionMapping> result =
        //        collection.Find<OptionMapping>(filter).Project<OptionMapping>(projection);

        //    return result.ToList<OptionMapping>();
        //}

        //public string GetGlobalOption(string country, string hs, string ht, string oegCode)
        //{
        //    IMongoCollection<OptionMapping> collection = GetOptionsCollection<OptionMapping>();

        //    FilterDefinition<OptionMapping> filter =
        //        Builders<OptionMapping>.Filter.And(
        //            Builders<OptionMapping>.Filter.In<string>("COUNTRY_ID", GetCountryCodes(country)),
        //            Builders<OptionMapping>.Filter.Eq<string>("HS", hs),
        //            Builders<OptionMapping>.Filter.Eq<string>("HT", ht),
        //            Builders<OptionMapping>.Filter.Or(
        //                Builders<OptionMapping>.Filter.Eq<string>("OEG_CODE", oegCode),
        //                Builders<OptionMapping>.Filter.Eq<string>("EQUIP_DESCRIPTION", oegCode)));

        //    ProjectionDefinition<OptionMapping> projection =
        //        Builders<OptionMapping>.Projection
        //        .Exclude("_id")
        //        .Exclude("COUNTRY_ID")
        //        .Exclude("AV_DESCRIPTION")
        //        .Exclude("AV_EXCLUSIONS");

        //    IFindFluent<OptionMapping, OptionMapping> result =
        //        collection.Find<OptionMapping>(filter).Project<OptionMapping>(projection);

        //    IList<OptionMapping> list = result.ToList<OptionMapping>();
        //    string option = (list.Count > 0) ? string.Join(",", list[0].QapterOption) : "";
        //    return option;
        //}

        #endregion
    }
}
