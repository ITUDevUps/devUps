import {createContext} from 'react';
import {User} from "../Types";

interface IUsercontext {
	user: User | null;
	setUser?: (user: User) => void;
}

const defaultUserContext: IUsercontext = {
	user: null,
}

export const UserContext = createContext<IUsercontext>(defaultUserContext);
