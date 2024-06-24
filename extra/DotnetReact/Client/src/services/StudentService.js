import axios from "axios";

const axiosInstance = axios.create({
    baseURL: 'https://localhost:7023/api',
    timeout: 10000,
    headers: {
        'Content-Type': 'application/json',
        "Access-Control-Allow-Origin": "*",
        'Access-Control-Allow-Methods':'GET,PUT,POST,DELETE,PATCH,OPTIONS'
    }
})

class StudentService{
 
    createStudent(data){
        return axiosInstance.post(`/students`, data)
    }

    getStudents(){
        return axiosInstance.get("/students")
    }

    deleteStudent(id){
        return axiosInstance.delete(`/students/${id}`)
    }

    updateStudent(data){
        return axiosInstance.put(`/students/${data.id}`, data)
    }

    getOneStudent(id){
        return axiosInstance.get(`/students/${id}`)
    }

}

export default new StudentService();