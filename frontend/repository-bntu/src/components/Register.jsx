import { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const Register = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.post('/api/auth/register', { email, password });
            navigate('/login');
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="mx-auto p-4 bg-primary min-h-screen flex justify-center items-center">
            <div className="bg-white p-8 rounded shadow-md w-full max-w-md">
                <h2 className="text-2xl font-bold mb-6 text-center">Регистрация</h2>
                <form onSubmit={handleSubmit} className="space-y-4">
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Почта</label>
                        <input
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            className="mt-1 p-2 block w-full border border-gray-300 rounded-md shadow-sm"
                            required
                        />
                    </div>
                    <div>
                        <label className="block text-sm font-medium text-gray-700">Пароль</label>
                        <input
                            type="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            className="mt-1 p-2 block w-full border border-gray-300 rounded-md shadow-sm"
                            required
                        />
                    </div>
                    <button type="submit" className="w-full py-2 bg-blue-500 text-white rounded hover:bg-blue-600">Регистрация</button>
                </form>
            </div>
        </div>
    );
};

export default Register;
