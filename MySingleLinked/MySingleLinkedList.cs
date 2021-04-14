using System;
using System.Collections.Generic;
using System.Text;

namespace MySingleLinked
{
    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MySingleLinkedList<T>
    {
        private int count;  //当前链表节点个数
        private Node<T> head; //当前链表头节点

        public int Count
        {
            get { return this.count; }
        }
        public MySingleLinkedList()
        {
            this.count = 0;
            this.head = null;
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return this.GetNodeByIndex(index).Item; }

            set { this.GetNodeByIndex(index).Item = value; }
        }

        /// <summary>
        /// 获取当前节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("Index", "索引超出范围");
            }

            Node<T> tempNode = this.head;
            //根据索引不断获取下一个
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }
            return tempNode;
        }

        /// <summary>
        /// 从尾部新增一个节点
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (this.head==null)
            {
                this.head = newNode;
            }
            else
            {
                Node<T> preNode = this.GetNodeByIndex(this.count - 1);
                preNode.Next = newNode;
            }

            this.count++;
        }

        /// <summary>
        /// 在指定位置后面插入一个节点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, T value)
        {
            Node<T> tempNode = null;
            if (index<0||index>this.count)
            {
                throw new ArgumentOutOfRangeException("Index","索引超出范围");
            }
            else if (index==0)
            {
                if (this.head==null)
                {
                    tempNode = new Node<T>(value);
                    this.head = tempNode;
                }
                else
                {
                    tempNode = new Node<T>(value);
                    tempNode.Next = this.head;
                    this.head = tempNode;
                 
                }
            }
            else
            {
                Node<T> preNode = this.GetNodeByIndex(index - 1);
                tempNode = new Node<T>(value);
                tempNode.Next = preNode.Next;
                preNode.Next = tempNode;
            }

            this.count++;

        }

        /// <summary>
        /// 移除指定位置的节点
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index==0)
            {
                this.head = this.head.Next;
            }
            else
            {
                Node<T> preNode = this.GetNodeByIndex(index - 1);
                if (preNode==null)
                {
                    throw new ArgumentOutOfRangeException("Index","索引超出范围");
                }

                Node<T> deleteNode = preNode.Next;
                preNode.Next = deleteNode.Next;

                deleteNode = null;
            }

            this.count--;
        }
    }
}
