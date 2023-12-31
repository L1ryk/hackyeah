﻿using Newtonsoft.Json;

namespace Scrap.PublicEntity;

public class Voivodeship
{
    [ JsonProperty( PropertyName = "id" ) ]
    public string Id { get; set; }

    [ JsonProperty( PropertyName = "name" ) ]
    public string Name { get; set; }

    [ JsonProperty( PropertyName = "levelName" ) ]
    public string LevelName { get; set; }
}