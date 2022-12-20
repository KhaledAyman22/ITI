#include <iostream>
#include <conio.h>

using namespace std;

template<class T>
class Queue{
    int size, tail;
    T* queue;
public:
    Queue(int _size){
        size = _size;
        tail = 0;
        queue = new T[size];
    }

    ~Queue(){
        delete []queue;
    }

    bool IsFull(){
        return tail == size;
    }

    bool IsEmpty(){
        return tail == 0;
    }

    void Enqueue(T n){
        if(!IsFull()) queue[tail++] = n;
        else cout << "The queue is full";
    }

    T Dequeue(){
        if(!IsEmpty()){
            int tmp = queue[0];

            for (int i = 0; i < tail-1; ++i) {
                queue[i] = queue[i+1];
            }
            tail--;
            return tmp;
        }
        else{
            cout << "The queue is empty" << endl;
            return -1;
        }
    }

    T Peek(){
        if(!IsEmpty()) return queue[0];
        else {
            cout << "The queue is empty" << endl;
            return -1;
        }
    }

    int GetCount(){
        return tail;
    }

};

template<class T>
class Array{
    int size;
    T* arr;
public:
    Array(int s){
        size = s;
        arr = new T[size];
    }

    Array(const Array& array){
        Array new_array(array.size);

        for (int i = 0; i < array.size; ++i) {
            new_array[i] = arr[i];
        }
    }

    ~Array(){
        delete[] arr;
    }

    Array& operator = (const Array& array){
        delete[] arr;
        arr = new int[array.size];

        for (int i = 0; i < array.size; ++i) {
            arr[i] = array.arr[i];
        }

        return *this;
    }

    T& operator [](int i){
        if(i < size && i > -1)
            return arr[i];
    }

    int GetSize(){
        return size;
    }
};

template<typename T>
class Stack{
    int top, size;
    T* stack;

public:
    Stack(int _size){
        top = 0;
        size = _size;
        stack = new T [size];
    }

    ~Stack(){
        delete []stack;
    }

    bool IsFull() const{
        return top==size;
    }

    bool IsEmpty() const{
        return top==0;
    }

    T Pop(){
        if(!IsEmpty()) return stack[--top];
        else {
            cout << "The stack is empty" << endl;
            return  -1;
        }
    }

    void Push(int n){
        if(!IsFull()) stack[top++] = n;
        else cout << "The stack is full";
    }

    T Peek(){
        if(!IsEmpty()) return stack[top-1];
        else {
            cout << "The stack is empty" << endl;
            return  -1;
        }
    }

    int GetCount() const{
        return size - top - 1;
    }

    Stack operator + (const Stack& s){
        Stack combined(size + s.size);

        for (int i = 0; i < top; ++i) {
            combined.Push(stack[i]);
        }

        for (int i = 0; i < s.top; ++i) {
            combined.Push(s.stack[i]);
        }

        return combined;
    }

    T operator [] (int i){
        if(i < size && i > -1)
            return stack[i];

        return INT32_MIN;
    }

    Stack& operator = (Stack const &s){
        delete[] stack;
        top = s.top;
        size = s.size;
        stack = new int[size];

        for (int i = 0; i < top; ++i) {
            stack[i] = s.stack[i];
        }

        return *this;
    }

    void Print(){
        for (int i = 0; i < top; ++i) {
            cout << stack[i] << " ";
        }

        cout << endl;
    }
};

int main() {
    Stack<int> s(5);
    Queue<char> q(5);
    Array<bool> b(5);

    s.Push(1);
    cout << s.Pop() << endl;

    q.Enqueue('a');
    cout << q.Dequeue() << endl;

    b[0] = true;
    cout << (b[0] == 1? "true":"false") << endl;

    _getch();
    return 0;
}
