#include <conio.h>
struct Employee {
    int id, age;
    char gender, name[21], address[21];
    double salary, overtime, tax;
};

void ReadEmployeeData(struct Employee *employees);
void PrintEmployeeData(struct Employee *employees);
void PrintEmployeesData(struct Employee *employees);
void DeleteEmployeeById(struct Employee *employees);
void DeleteEmployeeByName(struct Employee *employees);
int IdExists(struct Employee *employees, int id);

void ReadEmployeeData(struct Employee *employees){

    int x_pos[8] = {FORM_FIRST_COLUMN+10,FORM_FIRST_COLUMN+10,FORM_FIRST_COLUMN+10,FORM_FIRST_COLUMN+10,
                    FORM_SECOND_COLUMN+10,FORM_SECOND_COLUMN+10,FORM_SECOND_COLUMN+10,FORM_SECOND_COLUMN+10 },

        y_pos[8] = {FORM_START_ROW, FORM_START_ROW+2, FORM_START_ROW+4, FORM_START_ROW+6,
                    FORM_START_ROW, FORM_START_ROW+2, FORM_START_ROW+4, FORM_START_ROW+6 },

        data_size[8] = {3, 20, 2, 1, 20, 5, 4, 4 };

    char char_set[8] = {'0','a', '0', 'a', 'a', '0', '0', '0' };

    GoToXY(FORM_FIRST_COLUMN+10, 3);
    printf("ENTER employee's data:\n");

    struct Employee emp;
    char** tmp = LineEditor(x_pos, y_pos, char_set, data_size);

    for (int i = 0; i < 8; ++i) {
        for (int j = 0; j < data_size[i]; ++j) {
            if(i == 1 || i == 3 || i == 4){
                if(tmp[i][j] == '_')
                    tmp[i][j] = ' ';
            }

            else if(tmp[i][j] == '_')
                tmp[i][j] = '\0';
        }
    }

    if(IdExists(employees, atoi(tmp[0]))) {
      printf("ID already exists!!\n");
      Sleep(1200);
      return;
    }

    emp.id = atoi(tmp[0]);
    strcpy(emp.name, tmp[1]);
    emp.age = atoi(tmp[2]);
    emp.gender = (char)(tmp[3][0]);
    strcpy(emp.address, tmp[4]);
    emp.salary = atof(tmp[5]);
    emp.overtime = atof(tmp[6]);
    emp.tax = atof(tmp[7]);

    free(tmp);

    for (int i = 0; i < EMPLOYEE_COUNT; ++i) {
        if(employees[i].id == -1){
            employees[i] = emp;
            break;
        }
    }

    GoToXY(FORM_FIRST_COLUMN+10, 20);
    printf("Saving employee data...");
    Sleep(1200);
    system("cls");
}

void PrintEmployeeData(struct Employee *employees){
    while(1){
        int id,found=0;
        printf("ENTER employee ID:\n");
        scanf("%d", &id);

        for (int i = 0; i < EMPLOYEE_COUNT; ++i) {
            if(employees[i].id==id){
                printf("Employee's ID is: %d\n", employees[i].id);
                printf("Employee's name is: %s\n", employees[i].name);
                printf("Employee's address is: %s\n", employees[i].address);
                printf("Employee's age is: %d\n", employees[i].age);
                printf("Employee's gender is: %c\n", employees[i].gender);
                printf("Employee net is: %lf\n", employees[i].salary + employees[i].overtime - employees[i].tax);
                found=1;
                break;
            }
        }

        if(!found){
            printf("No employee with the given ID\n");
        }

        printf("Return  to main menu? [y/n]\n");
        char c = (char)_getch();

        if(c=='y') break;
        else system("cls");

        _flushall();
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
        printf("ENTER employee id: ");
        int id;
        scanf("%d", &id);

        for (int i = 0; i < EMPLOYEE_COUNT; ++i)
            if(employees[i].id == id){
                employees[i].id = -1;
                return;
            }

        printf("No employee with the given ID!!\n");

        printf("Return to main menu? [y/n]\n");
        char c = (char)_getch();
        if(c=='y') break;
        else system("cls");
    }
}

void DeleteEmployeeByName(struct Employee *employees){
    while(1){
        printf("ENTER employee name: ");
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
        char c = (char)_getch();
        if(c=='y') break;
        else system("cls");
    }
}

int IdExists(struct Employee *employees, int id){
    for (int i = 0; i < EMPLOYEE_COUNT; ++i) {
        if(employees[i].id == id) return 1;
    }
    return 0;
}
