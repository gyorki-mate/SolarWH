﻿using MongoDB.Bson;
using MongoDB.Driver;

namespace SWH.Models;

using MongoDB.Bson.Serialization.Attributes;

public class Product
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    public int Quantity { get; set; }
    public ProductType ProductType { get; set; }

}