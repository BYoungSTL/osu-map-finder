import { Button } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import './Auth.scss'

const Auth = () => {
    return (
        <div className="login-form">
            <Form>
                <h2>Osu Map Finder</h2>
                <p className='mb-5'>Some desc</p>
                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Control className='input-form' type="email" placeholder="Username" />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Control className='input-form' type="password" placeholder="Password" />
                </Form.Group>
                <Form.Group className="check-form mb-4" controlId="formBasicCheckbox">
                    <input type='checkbox' className='form-check-input mt-0 checkbox' value='' id='checkbox-input'/>
                    <label htmlFor="checkbox-input" className='ms-2'>Check me out</label>
                </Form.Group>
                <Button className='button' variant="primary" type="submit"  >
                    Submit
                </Button>
            </Form>
        </div>
    );
}

export default Auth;