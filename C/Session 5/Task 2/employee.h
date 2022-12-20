struct Employee {
    int id, age;
    char gender, name[100], address[200];
    double salary, overtime, tax;
};

void ReadEmployeesData(struct Employee *employees);
void PrintEmployeesData(struct Employee *employees);
int CheckIDExists(struct Employee *employees, int id);

void ReadEmployeesData(struct Employee *employees){
    for (int i = 0; i < 3; ++i) {
        printf("Enter data of employee %d/3:\n", i+1);

        struct Employee emp;

        printf("Enter employee ID:\n");
        scanf("%d", &emp.id);

        if(CheckIDExists(employees, emp.id)) {
            printf("ID already exists!!\nRe-Enter the data\n");
            i--;
            continue;
        }

        printf("Enter employee age:\n");
        scanf("%d", &emp.age);

        _flushall();
        printf("Enter employee gender:\n");
        scanf("%c", &emp.gender);

        _flushall();
        printf("Enter employee name:\n");
        gets(emp.name);

        _flushall();
        printf("Enter employee address:\n");
        gets(emp.address);

        _flushall();
        printf("Enter employee salary:\n");
        scanf("%lf", &emp.salary);

        printf("Enter employee overtime:\n");
        scanf("%lf", &emp.overtime);

        printf("Enter employee tax:\n");
        scanf("%lf", &emp.tax);

        employees[i] = emp;

        printf("Saving employee %d/3...", i+1);
        Sleep(1200);
        system("cls");
    }
}

void PrintEmployeesData(struct Employee *employees){
    printf("Your employees data is:\n");

    for (int i = 0; i < 3; ++i) {
        printf("Employee %d/3 ID is: %d\n", i+1, employees[i].id);
        printf("Employee %d/3 name is: %s\n", i+1, employees[i].name);
        printf("Employee %d/3 net is: %lf\n", i+1, employees[i].salary + employees[i].overtime - employees[i].tax);
    }

    while(1){
        printf("Return? [y/n]\n");
        char c = getche();
        if(c=='y') break;
        printf("\n");
    }
}

int CheckIDExists(struct Employee *employees, int id){
    for (int i = 0; i < 3; ++i) {
        if(employees[i].id == id) return 1;
    }
    return 0;
}
