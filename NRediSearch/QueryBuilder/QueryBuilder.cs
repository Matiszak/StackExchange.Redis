﻿// .NET port of https://github.com/RedisLabs/JRediSearch/

namespace NRediSearch.QueryBuilder
{
    /// <summary>
    /// This class contains methods to construct query nodes. These query nodes can be added to parent query
    /// nodes (building a chain) or used as the root query node.
    ///
    /// You can use <pre>using static</pre> for these helper methods.
    /// </summary>
    public static class QueryBuilder
    {


        public static QueryNode Intersect() => new IntersectNode();

        /// <summary>
        /// Create a new intersection node with child nodes. An intersection node is true if all its children
        /// are also true
        /// </summary>
        /// <param name="n">sub-condition to add</param>
        /// <returns>The node</returns>
        public static QueryNode Intersect(params INode[] n)
        {
            return Intersect().Add(n);
        }


        /// 
        /// Create a new intersection node with a field-value pair.
        /// @param field The field that should contain this value. If this value is empty, then any field
        ///              will be checked.
        /// @param values Value to check for. The node will be true only if the field (or any field)
        ///               contains <i>all</i> of the values
        /// @return The node
        /// 
        public static QueryNode Intersect(string field, params Value[] values)
        {
            return Intersect().Add(field, values);
        }

        /// 
        /// Helper method to create a new intersection node with a string value.
        /// @param field The field to check. If left null or empty, all fields will be checked.
        /// @param stringValue The value to check
        /// @return The node
        /// 
        public static QueryNode Intersect(string field, string stringValue)
        {
            return Intersect(field, Values.Value(stringValue));
        }

        public static QueryNode Union() => new UnionNode();

        /// 
        /// Create a union node. Union nodes evaluate to true if <i>any</i> of its children are true
        /// @param n Child node
        /// @return The union node
        /// 
        public static QueryNode Union(params INode[] n)
        {
            return Union().Add(n);
        }

        /// 
        /// Create a union node which can match an one or more values
        /// @param field Field to check. If empty, all fields are checked
        /// @param values Values to search for. The node evaluates to true if {@code field} matches
        ///               any of the values
        /// @return The union node
        /// 
        public static QueryNode Union(string field, params Value[] values)
        {
            return Union().Add(field, values);
        }

        /// 
        /// Convenience method to match one or more strings. This is equivalent to
        /// {@code union(field, value(v1), value(v2), value(v3)) ...}
        /// @param field Field to match
        /// @param values Strings to check for
        /// @return The union node
        /// 
        public static QueryNode Union(string field, params string[] values)
        {
            return Union(field, Values.Value(values));
        }

        public static QueryNode Disjunct() => new DisjunctNode();

        /// 
        /// Create a disjunct node. Disjunct nodes are true iff <b>any</b> of its children are <b>not</b> true.
        /// Conversely, this node evaluates to false if <b>all</b> its children are true.
        /// @param n Child nodes to add
        /// @return The disjunct node
        /// 
        public static QueryNode Disjunct(params INode[] n)
        {
            return Disjunct().Add(n);
        }

        /// 
         /// Create a disjunct node using one or more values. The node will evaluate to true iff the field does not
         /// match <b>any</b> of the values.
         /// @param field Field to check for (empty or null for any field)
         /// @param values The values to check for
         /// @return The node
         /// 
        public static QueryNode Disjunct(string field, params Value[] values)
        {
            return Disjunct().Add(field, values);
        }

        /// 
         /// Create a disjunct node using one or more values. The node will evaluate to true iff the field does not
         /// match <b>any</b> of the values.
         /// @param field Field to check for (empty or null for any field)
         /// @param values The values to check for
         /// @return The node
         /// 
        public static QueryNode Disjunct(string field, params string[] values)
        {
            return Disjunct(field, Values.Value(values));
        }

        public static QueryNode DisjunctUnion() => new DisjunctUnionNode();

        /// 
        /// Create a disjunct union node. This node evaluates to true if <b>all</b> of its children are not true.
        /// Conversely, this node evaluates as false if <b>any</b> of its children are true.
        /// @param n
        /// @return The node
        /// 
        public static QueryNode DisjunctUnion(params INode[] n)
        {
            return DisjunctUnion().Add(n);
        }

        public static QueryNode DisjunctUnion(string field, params Value[] values)
        {
            return DisjunctUnion().Add(field, values);
        }

        public static QueryNode DisjunctUnion(string field, params string[] values)
        {
            return DisjunctUnion(field, Values.Value(values));
        }

        public static QueryNode Optional() => new OptionalNode();

        /// 
        /// Create an optional node. Optional nodes do not affect which results are returned but they influence
        /// ordering and scoring.
        /// @param n The node to evaluate as optional
        /// @return The new node
        /// 
        public static QueryNode Optional(params INode[] n)
        {
            return Optional().Add(n);
        }
        public static QueryNode Optional(string field, params Value[] values)
        {
            return Optional().Add(field, values);
        }
    }
}
