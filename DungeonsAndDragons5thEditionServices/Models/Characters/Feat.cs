using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DungeonsAndDragons5thEditionServices
{
    public class Feat
    {
        #region Private Properties
        [BsonElement(elementName: "FeatName")]
        private string _featName;
        [BsonElement(elementName: "Description")]
        private string _description;
        [BsonElement(elementName: "Prerequisites")]
        private List<string> _prerequisites;
        [BsonElement(elementName: "Details")]
        private List<string> _details;
        #endregion

        #region Public Properties
        public string FeatName { get => _featName; set => _featName = value; }
        public string Description { get => _description; set => _description = value; }
        public List<string> Prerequisites { get => _prerequisites; set => _prerequisites = value; }
        public List<string> Details { get => _details; set => _details = value; }
        #endregion
    }
}
