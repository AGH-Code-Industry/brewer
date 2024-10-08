﻿using System.Collections.Generic;
using DataPersistence.HelperStructures;
using Settings;

namespace DataPersistence.Data {
    [System.Serializable]
    public class TaskData {
        public List<TaskEntry> tasks = new List<TaskEntry>();
    }
}