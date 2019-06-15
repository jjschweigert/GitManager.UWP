using System;
using System.Collections.Generic;
using System.Text;
using static DataAccessLibrary.SQLite.DataType;

namespace DataAccessLibrary
{
    public static class SQLite
    {
        #region DataTypes Class

        public static class DataType
        {
            public enum Integer_T
            {
                INT,
                INTEGER,
                SMALL_INT,
                MEDIUM_INT,
                BIG_INT,
                UNSIGNED_BIG_INT,
                INT2,
                INT8
            }

            public enum Text_T
            {
                CHARACTER,
                VARCHAR,
                VARYING_CHARACTER,
                NCHAR,
                NATIVE_CHARACTER,
                NVARCHAR,
                TEXT,
                CLOB
            }

            public enum Real_T
            {
                REAL,
                DOUBLE,
                DOUBLE_PRECISION,
                FLOAT
            }

            public enum Numeric_T
            {
                NUMERIC,
                DECIMAL,
                BOOLEAN,
                DATE,
                DATETIME
            }

            public enum None_T
            {
                BLOB
            }
        }

        #endregion


        #region Other Types

        public enum Operation_T
        {
            CREATE_DATABASE,
            CREATE_TABLE,
            DROP_TABLE,
            INSERT,
            SELECT,
            UPDATE,
            DELETE,
        }

        public enum Clause_T
        {
            WHERE,
            AND,
            OR,
            LIKE,
            GLOB,
            LIMIT,
            ORDER_BY,
            GROUP_BY,
            HAVING
        }

        public enum Keyword_T
        {
            DISTINCT
        }

        #endregion


        #region ToString Methods

        public static string ToString(Integer_T Int)
        {
            switch(Int)
            {
                case Integer_T.BIG_INT:
                    return "BIGINT";

                case Integer_T.INT:
                    return "INT";

                case Integer_T.INT2:
                    return "INT2";

                case Integer_T.INT8:
                    return "INT8";

                case Integer_T.INTEGER:
                    return "INTEGER";

                case Integer_T.MEDIUM_INT:
                    return "MEDIUMINT";

                case Integer_T.SMALL_INT:
                    return "SMALLINT";

                case Integer_T.UNSIGNED_BIG_INT:
                    return "UNSIGNED BIG INT";

                default:
                    return "";
            }
        }

        public static string ToString(Text_T Text)
        {
            switch(Text)
            {
                case Text_T.CHARACTER:
                    return "CHARACTER({0})";

                case Text_T.CLOB:
                    return "CLOB";

                case Text_T.NATIVE_CHARACTER:
                    return "NATIVE CHARACTER({0})";

                case Text_T.NCHAR:
                    return "NCHAR({0})";

                case Text_T.NVARCHAR:
                    return "NVARCHAR({0})";

                case Text_T.TEXT:
                    return "TEXT";

                case Text_T.VARCHAR:
                    return "VARCHAR({0})";

                case Text_T.VARYING_CHARACTER:
                    return "VARYING CHARACTER({0})";

                default:
                    return "";
            }
        }

        public static string ToString(None_T None)
        {
            switch(None)
            {
                case None_T.BLOB:
                    return "BLOB";

                default:
                    return "";
            }
        }

        public static string ToString(Real_T Real)
        {
            switch(Real)
            {
                case Real_T.DOUBLE:
                    return "DOUBLE";

                case Real_T.DOUBLE_PRECISION:
                    return "DOUBLE PRECISION";

                case Real_T.FLOAT:
                    return "FLOAT";

                case Real_T.REAL:
                    return "REAL";

                default:
                    return "";
            }
        }

        public static string ToString(Numeric_T Num)
        {
            switch(Num)
            {
                case Numeric_T.BOOLEAN:
                    return "BOOLEAN";

                case Numeric_T.DATE:
                    return "DATE";

                case Numeric_T.DATETIME:
                    return "DATETIME";

                case Numeric_T.DECIMAL:
                    return "DECIMAL({0},{1})";

                default:
                    return "";
            }
        }

        public static string ToString(Operation_T Op)
        {
            switch(Op)
            {
                case Operation_T.CREATE_DATABASE:
                    return "CREATE DATABASE";

                case Operation_T.CREATE_TABLE:
                    return "CREATE TABLE";

                case Operation_T.DELETE:
                    return "DELETE FROM {0} WHERE {1}";

                case Operation_T.DROP_TABLE:
                    return "DROP TABLE {0}";

                case Operation_T.INSERT:
                    return "INSERT INTO {0} [{1}] VALUES ({2})";

                case Operation_T.SELECT:
                    return "SELECT {0} FROM {1}";

                case Operation_T.UPDATE:
                    return "UPDATE {0} SET {1} WHERE {2}";

                default:
                    return "";
            }
        }

        public static string ToString(Clause_T Clause, bool LeadingClause = false)
        {
            string FullClause = "";

            switch(Clause)
            {
                case Clause_T.AND:

                    if(LeadingClause)
                    {
                        FullClause += "AND ";
                    }

                    FullClause += "{0} AND {1}";

                    return FullClause;

                case Clause_T.GLOB:
                    return "GLOB {0}";

                case Clause_T.GROUP_BY:
                    return "GROUP BY {0}";

                case Clause_T.HAVING:
                    return "HAVING {0}";

                case Clause_T.LIKE:
                    return "LIKE {0}";

                case Clause_T.LIMIT:
                    return "LIMIT {0}";

                case Clause_T.OR:

                    if(LeadingClause)
                    {
                        FullClause += "OR ";
                    }

                    FullClause += "{0} OR {1}";

                    return FullClause;

                case Clause_T.ORDER_BY:
                    return "ORDER BY {0}";

                case Clause_T.WHERE:
                    return "WHERE {0}";

                default:
                    return "";
            }
        }

        public static string ToString(Keyword_T Keyword)
        {
            switch(Keyword)
            {
                case Keyword_T.DISTINCT:
                    return "DISTINCT";

                default:
                    return "";
            }
        }

        #endregion
    }
}
