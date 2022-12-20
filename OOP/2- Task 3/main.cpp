#include <iostream>
#include <conio.h>
#include <windows.h>
using namespace std;

class Queue{
    int* queue, size, head, tail, count;

public:
    Queue(int _size){
        size = _size;
        head = tail = -1;
        count = 0;
        queue = new int[size];
    }

    ~Queue(){
        delete queue;
    }

    bool IsFull(){
        if ((head == 0 && tail == size - 1) || (head == tail + 1)) return true;
        return false;
    }

    bool IsEmpty(){
        return head == -1;
    }

    void Enqueue(int n){
        if(!IsFull()){
            if (head == -1) head++;
            tail = (tail + 1) % size;
            queue[tail] = n;
            count++;
        }
        else cout << "The queue is full";
    }

    int Dequeue(){
        if(!IsEmpty()){
            int tmp = queue[head];

            if (head == tail) head = tail = -1;
            else head = (head + 1) % size;

            count--;
            return tmp;
        }
        else{
            cout << "The queue is empty" << endl;
            return -1;
        }
    }

    int Peek(){
        if(!IsEmpty()) return queue[head];
        else {
            cout << "The queue is empty" << endl;
            return -1;
        }
    }

    int GetCount(){
        return count;
    }
};


int main() {

    int choice, size;
    cout << "Enter queue size: ";
    cin >> size;

    Queue queue{size};

    while(true){
        cout << endl << endl;
        cout << "Press 1 to enqueue, 2 to dequeue, 3 to peek, 4 to get count, 5 to exit" << endl;
        cin >> choice;


        switch (choice) {
            case 1: {
                cout << "Enter a number: ";
                int n;
                cin >> n;

                queue.Enqueue(n);
                break;
            }

            case 2:{
                int tmp = queue.Dequeue();
                if(tmp!=-1)
                    cout << "Number " << tmp << " is dequeued" << endl;
                break;
            }

            case 3:{
                int tmp = queue.Peek();
                if(tmp!=-1)
                    cout << "Number " << tmp << " is the front of the queue" << endl;
                break;
            }

            case 4:{
                cout << "There is " << queue.GetCount() << " elements in the queue" << endl;
                break;
            }

            case 5: { _getch(); return 0; }

            default: break;
        }
    }
}

