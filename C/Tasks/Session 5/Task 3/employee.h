struct Employee {
    int id, age;
    char gender, name[100], address[200];
    double salary, overtime, tax;
};

void ReadEmployeeData(struct Employee *employees);
void PrintEmployeeData(struct Employee *employees);
void PrintEmployeesData(struct Employee *employees);
void DeleteEmployeeById(struct Employee *employees);
void DeleteEmployeeByName(struct Employee *employees);
int CheckIDExists(struct Employee *employees, int id);

void ReadEmployeeData(struct Employee *employees){
    GoToXY(FORM_FIRST_COLUMN+10, 3);
    printf("Enter employee's data:\n");

    struct Employee emp;

    GoToXY(FORM_FIRST_COLUMN+10, FORM_START_ROW);
    scanf("%d", &emp.id);

    if(CheckIDExists(employees, emp.id)) {
        printf("ID already exists!!\nRe-Enter the data\n");
    }

    _flushall();
    GoToXY(FORM_FIRST_COLUMN+10, FORM_START_ROW+2);
    gets(emp.name);

    GoToXY(FORM_FIRST_COLUMN+10, FORM_START_ROW+4);
    scanf("%d", &emp.age);

    _flushall();
    GoToXY(FORM_FIRST_COLUMN+10, FORM_START_ROW+6);
    scanf("%c", &emp.gender);

    _flushall();
    GoToXY(FORM_SECOND_COLUMN+10, FORM_START_ROW);
    gets(emp.address);

    _flushall();
    GoToXY(FORM_SECOND_COLUMN+10, FORM_START_ROW+2);
    scanf("%lf", &emp.salary);

    GoToXY(FORM_SECOND_COLUMN+10, FORM_START_ROW+4);
    scanf("%lf", &emp.overtime);

    GoToXY(FORM_SECOND_COLUMN+10, FORM_START_ROW+6);
    scanf("%lf", &emp.tax);

    for (int i = 0; i < EMPLOYEE_COUNT; ++i) {
        if(employees[i].id == -1){
            employees[i] = emp;
            break;
        }
    }
    printf("Saving employee data...");
    Sleep(1200);
    system("cls");
}

void PrintEmployeeData(struct Employee *employees){
    while(1){
        int id,found=0;
        printf("Enter employee ID:\n");
        scanf("%d", &id);

        for (int i = 0; i < EMPLOYEE_COUNT; ++i) {
            if(employees[i].id==id){
                printf("Employee ID is: %d\n", employees[i].id);
                printf("Employee name is: %s\n", employees[i].name);
                printf("Employee net is: %lf\n", employees[i].salary + employees[i].overtime - employees[i].tax);
                found=1;
                break;
            }
        }

        if(!found){
            printf("No employee with the given ID\n");
        }

        printf("Return  to main menu? [y/n]\n");
        char c = getch();

        if(c=='y') break;
        else system("cls");
    }
}

void PrintEmployeesData(struct Employee *employees){
    int found_any=0;

    for (int i = 0; i < EMPLOYEE_COUNT; ++i) {
        if(employees[i].id == -1) break;
        else {
            if(!found_any) printf("Your employees data is:\n");

            printf("Employee %d/%d ID is: %d\n", i + 1, EMPLOYEE_COUNT, employees[i].id);
            printf("Employee %d/%d name is: %s\n", i + 1, EMPLOYEE_COUNT, employees[i].name);
            printf("Employee %d/%d net is: %lf\n", i + 1, EMPLOYEE_COUNT,
                   employees[i].salary + employees[i].overtime - employees[i].tax);
            found_any = 1;
        }
    }

    if(!found_any) printf("No employees yet! \n");

    printf("\nPress any key to return\n");
    getch();
    _flushall();
}

void DeleteEmployeeById(struct Employee *employees){
    while(1){
        printf("Enter employee id: ");
        int id;
        scanf("%d", &id);

        for (int i = 0; i < EMPLOYEE_COUNT; ++i)
            if(employees[i].id == id){
                employees[i].id = -1;
                return;
            }

        printf("No employee with the given ID!!\n");

        printf("Return to main menu? [y/n]\n");
        char c = getch();
        if(c=='y') break;
        else system("cls");
    }
}

void DeleteEmployeeByName(struct Employee *employees){
    while(1){
        printf("Enter employee name: ");
        char name[100];
        _flushall();
        gets(name);

        for (int i = 0; i < EMPLOYEE_COUNT; ++i)
            if(strcmp(employees[i].name, name) == 0){
                employees[i].id = -1;
                printf("Employee deleted successfully.\n Saving...");
                Sleep(1300);
                return;
            }

        printf("No employee with the given name!!\n");

        printf("Return to main menu? [y/n]\n");
        char c = getch();
        if(c=='y') break;
        else system("cls");
    }
}

int CheckIDExists(struct Employee *employees, int id){
    for (int i = 0; i < EMPLOYEE_COUNT; ++i) {
        if(employees[i].id == id) return 1;
    }
    return 0;
}
