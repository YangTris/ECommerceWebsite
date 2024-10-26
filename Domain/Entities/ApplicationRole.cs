﻿using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	[CollectionName("Roles")]
	public class ApplicationRole : MongoIdentityRole<ObjectId>
    {
    }
}
