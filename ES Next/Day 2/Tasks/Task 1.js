function generateCourseInfo(info = {}) {
    const defaultInfo = {
        courseName: "ES6",
        courseDuration: "3 days",
        courseOwner: "JavaScript",
    };

    let courseInfo = { ...defaultInfo, ...info };

    for (const key in courseInfo) {
        if (!defaultInfo.hasOwnProperty(key)) {
            throw new Error(`Invalid property: ${key}`);
        }
    }

    return `Course Name: ${courseInfo.courseName}\nDuration: ${courseInfo.courseDuration}\nAuthor: ${courseInfo.courseOwner}`;
}

let res = generateCourseInfo({})
console.log(res)
console.log('*'.repeat(50))

res = generateCourseInfo({courseName: 'ES Next'})
console.log(res)
console.log('*'.repeat(50))

res = generateCourseInfo({courseName: 'ES Next', Grade: 70})
console.log(res)