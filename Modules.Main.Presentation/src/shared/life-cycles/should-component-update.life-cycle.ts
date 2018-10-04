
export interface IShouldComponentUpdate<P = {}, S = {}> {
    /**
     * Called to determine whether the change in props and state should trigger a re-render.
     *
     * `Component` always returns true.
     * `PureComponent` implements a shallow comparison on props and state and returns true if any
     * props or states have changed.
     *
     * If false is returned, `Component#render`, `componentWillUpdate`
     * and `componentDidUpdate` will not be called.
     * 
     * For more info -> https://reactjs.org/docs/react-component.html#shouldcomponentupdate
     * 
     * @param nextProps Updated props
     * @param nextState Updated state
     * @param nextContext Updated context
     * 
     * @returns return true if need to continue the update. False for cancel the update
     */
    shouldComponentUpdate(nextProps: Readonly<P>, nextState: Readonly<S>, nextContext: any): boolean;
}