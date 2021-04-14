using System;
using System.Collections.Generic;
using System.Text;

namespace MySingleLinked
{
    /// <summary>
    /// 链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// 数据区
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// 指针区
        /// </summary>
        public Node<T> Next { get; set; }


        public Node()
        {

        }

        public Node(T item)
        {
            this.Item = item;
        }
    }
}
