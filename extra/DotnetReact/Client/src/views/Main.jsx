import React, {useState, useEffect} from 'react'
import Dashboard from '../components/Dashboard'
import EditForm from '../components/EditForm'
import StudentForm from '../components/StudentForm'
import StudentService from '../services/StudentService'

const Main = () => {
    const [students, setStudents] = useState([]);
    const [refresh, setRefresh] = useState(true)
    
    const updateList = ()=>{
        setRefresh(!refresh);
    }

    useEffect(()=>{
        // http://localhost:7023/api/students
        StudentService.getStudents()
            .then(res=>{
                setStudents(res.data) 
            })
            .catch(err=>console.log(err.response))

    },[refresh])

    

    const filterList = (id)=>{
        const filterStudent = students.filter((eachStu, i)=> eachStu.id != id)
                setStudents(filterStudent)
    }

    return (
        <div className='container mt-5'>
            <Dashboard students={students} onUpdate={updateList} />
                <StudentForm onCreate={updateList}/>
        </div>
    )
}

export default Main