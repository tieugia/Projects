import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { TaskList } from "./components/TaskList";

const AppRoutes = [
    {
        index: true,
        element: <TaskList />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        element: <FetchData />
    }
];

export default AppRoutes;
