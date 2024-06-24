import React, { useState } from 'react'
import axios from 'axios';
import studentService from '../services/StudentService';

const StudentForm = (props) => {
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [errors, setErrors] = useState([]);

    // refactored axios config so that the header doesn't need to be repeated in every axios call
    const handleSubmit = (e) => {
        e.preventDefault();
        studentService.createStudent({ name, email })
            .then(res => {
                props.onCreate()
                clearForm();
            })
            .catch(err => {
                console.log(err.response.data)
                const responseDataDict = err.response.data.errors;
                const errArr = [];
                for (const key in responseDataDict) {
                    for(const msg of responseDataDict[key]){
                        errArr.push(msg);
                    }
                }
                setErrors(errArr);
            })
    }

    const clearForm = () => {
        setName("");
        setEmail("");
    }

    return (
        <div>
            <h1> Create</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <p> Name</p>
                    <input onChange={e => setName(e.target.value)} className="form-control" value={name} />
                </div>
                <div>
                    <p> Email</p>
                    <input onChange={e => setEmail(e.target.value)} className="form-control" value={email} />
                </div>
                <button className='btn btn-success'> Submit</button>
            </form>
            {
                errors.map((err, idx) => (
                    <p style={{ color: "red" }} key={idx}> {err}</p>
                ))
            }


        </div>
    )
}

export default StudentForm