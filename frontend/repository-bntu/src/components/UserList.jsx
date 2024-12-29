import { useEffect, useState } from 'react';
import axios from 'axios';

const UserList = () => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        axios.get('/api/users')
            .then(response => setUsers(response.data))
            .catch(error => console.error(error));
    }, []);

    return (
        <div className="container mx-auto p-4">
            <h2 className="text-2xl font-bold mb-4">Users</h2>
            <ul className="list-disc list-inside">
                {users.map(user => (
                    <li key={user.id} className="mb-2">
                        {user.email}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default UserList;
