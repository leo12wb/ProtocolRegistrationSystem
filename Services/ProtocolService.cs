using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProtocolRegistrationSystem.Models;

namespace ProtocolRegistrationSystem.Services
{
    public class ProtocolService
    {
        private readonly string _filePath = "wwwroot/data/protocols.json";

        public List<Protocol> GetAll()
        {
            if (!File.Exists(_filePath))
                return new List<Protocol>();

            string json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Protocol>>(json) ?? new List<Protocol>();
        }

        public void SaveAll(List<Protocol> protocolos)
        {
            string json = JsonConvert.SerializeObject(protocolos, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public void Add(Protocol protocol)
        {
            var protocols = GetAll();
            protocol.Id = protocols.Any() ? protocols.Max(p => p.Id) + 1 : 1;
            protocols.Add(protocol);
            SaveAll(protocols);
        }
    }
}
