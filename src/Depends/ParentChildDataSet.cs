using Depends.Core.Graph;
using System;
using System.Collections.Generic;
using System.Data;

namespace Depends
{
    /// <summary>
    /// ParentChild DataSet contains 2 tables - Parent and Child
    /// </summary>
    class ParentChildDataSet
    {
        static DataSet _dataSet;

        public ParentChildDataSet()
        {
            _dataSet = new DataSet();

            DataTable parentTable = CreateParentTable();
            DataTable childTable = CreateChildTable();

            _dataSet.Tables.Add(parentTable);
            _dataSet.Tables.Add(childTable);

            DataColumn parentColumn = parentTable.Columns["Id"];
            DataColumn childColumn = childTable.Columns["ParentId"];

            DataRelation parentChildRelation = new DataRelation("ParentChildRelation", parentColumn, childColumn);

            _dataSet.Relations.Add(parentChildRelation);

            //childTable.ParentRelations.Add(parentChildRelation);
        }

        /// <summary>
        /// Creates Parent table
        /// </summary>
        /// <returns>Parent table</returns>
        public DataTable CreateParentTable()
        {
            DataTable dataTable = new DataTable("Parent");

            // Create identity column
            DataColumn identityColumn = CreateIdentityColumn();
            dataTable.Columns.Add(identityColumn);
    
            // Create columns
            dataTable.Columns.Add("FileName", typeof(string));

            return dataTable;
        }

        /// <summary>
        /// Creates Child table
        /// </summary>
        /// <returns>Parent table</returns>
        public DataTable CreateChildTable()
        {
            DataTable dataTable = new DataTable("Child");

            // Create identity column
            DataColumn identityColumn = CreateIdentityColumn();
            dataTable.Columns.Add(identityColumn);

            // Create columns
            dataTable.Columns.Add("ParentId", typeof(int));
            dataTable.Columns.Add("FileName", typeof(string));

            return dataTable;
        }

        /// <summary>
        ///  Creates identiy column for table
        /// </summary>
        /// <returns>Identity column</returns>
        public DataColumn CreateIdentityColumn()
        {
            DataColumn column = new DataColumn();

            column.ColumnName = "Id";
            column.DataType = Type.GetType("System.Int32");
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 0;
            column.AutoIncrementStep = 1;

            return column;
        }

        public DataRelation CreateParentChildRelation(DataColumn parentColumn, DataColumn childColumn)
        {
            return new DataRelation("ParentChildRelation", parentColumn, childColumn);
        }


        /// <summary>
        /// Adds row to Parent table
        /// </summary>
        /// <param name="parent">Parent node</param>
        public void AddParentRow(Node parent)
        {           
            DataTable parentDataTable = _dataSet.Tables["Parent"];
            DataRow dataRow = parentDataTable.NewRow();

            dataRow["FileName"] = parent.Id;

            parentDataTable.Rows.Add(dataRow);            
        }

        /// <summary>
        /// Adds rows to Child table
        /// </summary>
        /// <param name="parent">Parent node</param>
        /// <param name="children">List of children nodes</param>
        public void AddChildRow(Node parent, List<Node> children)
        {
            DataTable childDataTable = _dataSet.Tables["Child"];
            DataRow dataRow;
            Node child;

            for (int i = 0; i < children.Count; i++)
            {
                child = children[i];

                dataRow = childDataTable.NewRow();
                dataRow["ParentId"] = parent.Id;
                //dataRow["FileName"] = child.
            }            

            //parentDataTable.Rows.Add(dataRow);
        }

    }
}
