import { useState, useEffect } from "react"
import React from 'react'
import axios from 'axios';
import StudentService from "../services/StudentService";
import EditForm from "./EditForm";


const Dashboard = (props) => {
    const { students, onUpdate } = props
    const [updateId, setUpdateId] = useState()

    const handleDelete = (id) => {
        StudentService.deleteStudent(id)
            .then(res => {
                onUpdate()
            })
            .catch(err => console.log(err))
    }

    const updatedStudent = () => {
        setUpdateId();
        onUpdate();
    }

    return (
        <div>
            <table className="table">
                <thead>
                    <tr>
                        <th> ID </th>
                        <th> Name</th>
                        <th> Email</th>
                        <th colSpan="2"> Actions </th>
                    </tr>
                </thead>
                <tbody>
                    {
                        students.map((student, i) => (
                            <tr key={i}>
                                <td> {student.id} </td>
                                <td> {student.name} </td>
                                <td> {student.email} </td>

                                    {
                                        updateId === student.id ?
                                            <td colSpan="2"><EditForm id={student.id} onUpdate={updatedStudent} /></td> :
                                            <>
                                                <td><button className="btn btn-warning" onClick={(e) => setUpdateId(student.id)} > Edit</button></td>
                                                <td><button className="btn btn-danger" onClick={(e) => handleDelete(student.id)} > Delete</button></td>
                                            </>
                                   
                                    
                                    }

                

                            </tr>
                        ))
                    }
                </tbody>
            </table>


        </div>
    )
}

export default Dashboard