using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineModel
{
    public class SingleHashTable
    {
        private object key;
        private object value;
        public object Key
        {
            get
            {
                return key;
            }
        }
        public object Value
        {
            get
            {
                return value;
            }
        }
        public SingleHashTable(object key, object value)
        {
            this.key = key;
            this.value = value;
        }
    }
    public class InfoHashTable : IEnumerable, IEnumerator//xml文件格式的对应的集合
    {
        private ArrayList keyArrayList;
        private ArrayList valueArrayList;
        private int position = -1;
        public InfoHashTable()
        {
            keyArrayList = new ArrayList();
            valueArrayList = new ArrayList();
        }
        public object[] Keys
        {
            get
            {
                return keyArrayList.ToArray();
            }
        }
        public object[] Values
        {
            get
            {
                return valueArrayList.ToArray();
            }
        }
        public void Add(object key, object value)
        {
            keyArrayList.Add(key);
            valueArrayList.Add(value);
        }
        public object this[String key]
        {
            get
            {
                for (int i = 0; i < keyArrayList.Count; i++)
                {
                    if (keyArrayList[i].ToString() == key)
                        return valueArrayList[i];
                }
                return null;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            position++;
            return (position < keyArrayList.Count);
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current
        {
            get
            {
                SingleHashTable hashTable = new SingleHashTable(keyArrayList[position], valueArrayList[position]);
                return hashTable;
            }
        }
    }
    public class ElementInfo
    {
        private String elementName;
        private bool hasChildNodes;
        public String ElementName
        {
            get
            {
                return elementName;
            }
        }
        public bool HasChildNodes
        {
            get
            {
                return hasChildNodes;
            }
        }
        public ElementInfo(String elementName, bool hasChildNodes)
        {
            this.elementName = elementName;
            this.hasChildNodes = hasChildNodes;
        }
    }
}
