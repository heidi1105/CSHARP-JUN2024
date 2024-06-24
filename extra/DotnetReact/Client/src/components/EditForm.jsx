import React from 'react'
import { useEffect, useState } from 'react';
import StudentService from '../services/StudentService';


const EditForm = (props) => {
    const { id } = props
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [errors, setErrors] = useState([])


    useEffect(() => {
        StudentService.getOneStudent(id)
            .then(res => {
                setName(res.data.name)
                setEmail(res.data.email)
            })
            .catch()
    }, [id])

    const handleSubmitService = (e) => {
        e.preventDefault();
        StudentService.updateStudent({ id, name, email })
            .then(res => {
                props.onUpdate();
            })
            .catch(err => {
                console.log(err.response.data)
                const responseData = err.response.data;
                const errArr = [];
                for(const errObj of responseData){
                    errArr.push(errObj.defaultMessage);
                }
                setErrors(errArr);
            })
    }

    return (
        <div>
            <form onSubmit={handleSubmitService}>
                <div class="row mb-3" >
                    <label class="col-sm-1 col-form-label">Name</label>
                    <div class="col-sm-4">
                        <input onChange={e => setName(e.target.value)} className="form-control" value={name} />
                    </div>
                    <label class="col-sm-1 col-form-label">Email</label>
                    <div class="col-sm-4">
                        <input onChange={e => setEmail(e.target.value)} className="form-control" value={email} />
                    </div>
                    <div class="col-sm-2">
                        <button className='btn btn-warning'> Confirm</button>
                    </div>
                </div>
            </form>
            {
            errors.map((err, idx)=>(
                <p style={{color: "red"}} key={idx}> {err}</p>
            ))
        }
        </div>
    )
}

export default EditForm